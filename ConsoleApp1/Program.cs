using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDBClassLibrary.Service;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieService m = new MovieService();
            RootObject a = m.FindPopularMovies(1, "863b8b07d72a6a0fdefb3c70fb492353");
        }
    }
}
