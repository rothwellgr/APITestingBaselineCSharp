FROM jenkins/jenkins:lts

COPY --chown=jenkins:jenkins plugins.txt /usr/share/jenkins/ref/plugins.txt
RUN jenkins-plugin-cli --plugin-file /usr/share/jenkins/ref/plugins.txt

COPY --chown=jenkins:jenkins jcasc.yml /usr/share/jenkins/ref/casc_configs/jcasc.yml
ENV CASC_JENKINS_CONFIG=/usr/share/jenkins/ref/casc_configs

COPY --chown=jenkins:jenkins create-pipeline.groovy /usr/share/jenkins/ref/init.groovy.d/create-pipeline.groovy

USER root
RUN apt-get update && apt-get install -y libicu-dev && rm -rf /var/lib/apt/lists/* && \
    curl -fsSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin -Channel 8.0 -InstallDir /usr/share/dotnet && \
    ln -s /usr/share/dotnet/dotnet /usr/local/bin/dotnet
USER jenkins
