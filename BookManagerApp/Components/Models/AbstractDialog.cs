using Microsoft.AspNetCore.Components;

namespace BookManagerApp.Components.Models
{
    public abstract class AbstractDialog : ComponentBase
    {
        protected TemplateDialog TemplateDialog { get; set; } = new TemplateDialog();

        public virtual void Show()
        {
            TemplateDialog.Show();
        }

        public virtual void Close()
        {
            TemplateDialog.Close();
        }
    }
}
