pipeline {
    agent any

    options {
        timestamps()
    }

    parameters {
        string(name: 'HTTPBIN_URL', defaultValue: 'http://httpbin:80',
               description: 'httpbin service URL')
    }

    stages {
        stage('Restore & Build') {
            steps {
                dir('/workspace') {
                    sh 'dotnet restore'
                    sh 'dotnet build --no-restore -c Debug'
                }
            }
        }

        stage('Test') {
            steps {
                dir('/workspace') {
                    sh """dotnet test --no-build -c Debug \
                        --logger:"trx;LogFileName=TestResults.trx" \
                        -e HTTPBIN_URL=${params.HTTPBIN_URL}
"""
                }
            }
            post {
                always {
                    step([$class: 'MSTestPublisher',
                          testResultsFile: '/workspace/TestResults/TestResults.trx'])
                }
            }
        }
    }
}
