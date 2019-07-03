using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public class Users
    {

        public string playerName;

        public Users(string setName = "Anonymous")
        {
            playerName = setName;
        }

    }
}
