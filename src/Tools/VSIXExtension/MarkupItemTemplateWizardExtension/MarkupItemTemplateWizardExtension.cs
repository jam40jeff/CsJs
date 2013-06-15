using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace MorseCode.CsJs.MarkupItemTemplateWizardExtension
{
    public class MarkupItemTemplateWizardExtension : IWizard
    {
        private ProjectItem _parentProjectItem;
        private ProjectItem _childProjectItem;

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void RunFinished()
        {
            string filename = _childProjectItem.FileNames[0];
            _parentProjectItem.ProjectItems.AddFromFile(filename);
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            if (projectItem.FileNames[0].EndsWith(".cs"))
            {
                _childProjectItem = projectItem;
            }
            else
            {
                _parentProjectItem = projectItem;
            }
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }
    }
}