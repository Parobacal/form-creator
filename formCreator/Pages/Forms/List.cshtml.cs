using formCreator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace formCreator.Pages.Forms
{
    public class ListModel : PageModel
    {
        private readonly AppDbContext _dbcontext;
        public List<formsList> formList { get; set; }
        public ListModel(AppDbContext DBContext)
        {
            _dbcontext = DBContext;
        }

        public List<forms> forms { get; set; }
        public void OnGet()
        {
            var formList_ = _dbcontext.forms.ToList();
            formList = new List<formsList>();
            foreach (forms form in formList_)
            {
                formsList new_list = new formsList();
                new_list.form = form;
                new_list.LatestVersion = _dbcontext.formVersions.FirstOrDefault(p => p.IsLatestVersion == true && p.Form.Id == form.Id).Version;
                formList.Add(new_list);
            }
        }


    }

    public class formsList
    {
        public Form form { get; set; }
        public int LatestVersion { get; set; }
    }
}
}
