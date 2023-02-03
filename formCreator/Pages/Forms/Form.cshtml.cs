using Azure;
using formCreator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using mtx.WebUI.Data.Models.forms;

namespace formCreator.Pages.Forms
{
    public class FormModel : PageModel
    {
        private readonly AppDbContext _dbcontext;
        public formVersions LastFormVersion { get; set; }
        public List<formVersions> ListVersions { get; set; }
        public string Name { get; set; }
        public string currentUser { get; set; }
        public int IdForm { get; set; }
        public int Latest { get; set; }
        public void OnGet(int Id)
        {

            currentUser = HttpContext.User.Identity.Name;
            LastFormVersion = new formVersions();
            if (Id > 0)
            {

                ListVersions = _dbcontext.formVersions.Where(s => s.Form.Id == Id).ToList();
                Name = _dbcontext.forms.AsNoTracking().First(p => p.Id == Id).Name;
                IdForm = Id;
                int index = 0;
                foreach (formVersions formVersion in ListVersions)
                {
                    if (formVersion.IsLatestVersion == true)
                    {
                        Latest = index;
                    }
                    index++;
                }

                LastFormVersion = _dbcontext.formVersions.FirstOrDefault(p => p.IsLatestVersion == true && p.Form.Id == Id);
            }
        }

        public IActionResult OnPostSavform(string Name, string Properties, string HTML)
        {

            var userFound = _dbcontext.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();


            var newForm = new forms()
            {
                Name = Name,
                CreatedDate = DateTime.Now,
                FormsVersions = new List<formVersions>(),
                Creator = _dbcontext.StaffMembers.FirstOrDefault(p => p.User == userFound)
            };

            newForm.FormsVersions.Add(new formVersions
            {
                Properties = Properties,
                HTML = HTML,
                IsLatestVersion = true,
                Version = 1,
                CreatedDate = DateTime.Now,
                Responses = new List<Responses>(),
                Drafts = new List<ResponseDrafts>()
            });

            _dbcontext.forms.Add(newForm);
            _dbcontext.SaveChanges();

            int formId = _dbcontext.forms.OrderByDescending(ef => ef.Id).FirstOrDefault().Id;

            return new ObjectResult(new { formID = formId }) { StatusCode = 201 };
        }

        public IActionResult OnPostUpdatform(int Id, string Name, string Properties, string HTML)
        {

            var formFound = _dbcontext.forms.Include(p => p.FormsVersions).FirstOrDefault(p => p.Id == Id);
            var latestVersionForm = _dbcontext.formVersions.FirstOrDefault(p => p.IsLatestVersion == true && p.Form.Id == Id);

            latestVersionForm.IsLatestVersion = false;
            _dbcontext.formVersions.Update(latestVersionForm);

            formFound.FormsVersions.Add(new formVersions
            {
                Properties = Properties,
                HTML = HTML,
                IsLatestVersion = true,
                Version = formFound.FormsVersions.Count() + 1,
                CreatedDate = DateTime.Now
            });


            _dbcontext.forms.Update(formFound);
            _dbcontext.SaveChanges();

            return new ObjectResult(new { Message = "" }) { StatusCode = 201 };
        }

        public IActionResult OnGetUpdateVersion(int IdForm)
        {
            ListVersions = _dbcontext.formVersions.Where(s => s.Form.Id == IdForm).ToList();
            LastFormVersion = _dbcontext.formVersions.FirstOrDefault(p => p.IsLatestVersion == true && p.Form.Id == IdForm);

            return new ObjectResult(new { data = ListVersions, version = LastFormVersion }) { StatusCode = 201 };
        }
    }
}
}
