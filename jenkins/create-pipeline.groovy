import jenkins.model.Jenkins
import org.jenkinsci.plugins.workflow.job.WorkflowJob
import org.jenkinsci.plugins.workflow.cps.CpsFlowDefinition

def jenkins = Jenkins.instance
def jobName = "APITestingBaselineCSharp"

if (jenkins.getItem(jobName) == null) {
    def job = jenkins.createProject(WorkflowJob, jobName)
    def jenkinsfile = new File("/workspace/Jenkinsfile").text
    job.definition = new CpsFlowDefinition(jenkinsfile, true)
    job.save()
    println "Created pipeline job: $jobName"
}
