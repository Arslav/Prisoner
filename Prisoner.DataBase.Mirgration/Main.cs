using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Prisoner.Test;

namespace Prisoner.DataBase.Mirgration
{
    class Source
    {
        static void Main(string[] args)
        {
            var context = new TestContext();
            context.Database.Migrate();
        }
    }
}
