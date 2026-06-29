.PHONY: build shell test test-remote jenkins clean

build:
	docker compose build

shell:
	docker compose run --rm dev

test:
	docker compose run --rm dev dotnet test

test-remote:
	docker compose run --rm -e HTTPBIN_URL=https://httpbin.org dev dotnet test

jenkins:
	docker compose -f docker-compose.jenkins.yml up -d --build
	@echo ""
	@echo "Jenkins starting at http://localhost:8080"
	@echo "Pipeline 'APITestingBaselineCSharp' auto-configures on startup."
	@echo "Trigger it ad-hoc via the Jenkins UI (Build with Parameters)."

clean:
	docker compose down --rmi all -v 2>/dev/null || true
