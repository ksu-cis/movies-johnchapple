using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        public MovieDatabase mdb = new MovieDatabase();
        public List<Movie> Movies;
        public void OnGet()
        {
            Movies = mdb.All;
        }

        public float minIMDB;

        public void OnPost(string search, List<string> mpaa)
        {
            if ((search != null) && (mpaa.Count > 0))
            {
                Movies = mdb.Search(search);
                Movies = mdb.Filter(Movies, mpaa);
            }
            else if (search != null)
            {
                Movies = mdb.Search(search);
            }
            else if (mpaa.Count > 0)
            {
                Movies = mdb.Filter(mdb.All, mpaa);
            }

            if (minIMDB is float min)
            {
                Movies = mdb.FilterByMinIMDB(Movies, min);
            }
        }
    }
}
