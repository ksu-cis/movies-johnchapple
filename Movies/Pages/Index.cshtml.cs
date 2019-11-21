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
        public List<Movie> Movies;
        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public float minIMDB;

        public void OnPost(string search, List<string> mpaa)
        {
            Movies = MovieDatabase.All;

            if (search != null)
            {
                Movies = MovieDatabase.Search(Movies, search);
            }

            if (mpaa.Count > 0)
            {
                Movies = MovieDatabase.Filter(Movies, mpaa);
            }

            if (minIMDB is float min)
            {
                Movies = MovieDatabase.FilterByMinIMDB(Movies, min);
            }
        }
    }
}
