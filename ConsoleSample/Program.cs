using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sample.Example04;

namespace ConsoleSample
{
    class Program
    {
        private static string phone = "+886911506909";
        static void Main(string[] args)
        {
            Example01();

            Example02();

            Example03();

            Example04();
        }

        private static void Example01()
        {
            Sample.Example01.QueryMember qm =
                new Sample.Example01.QueryMember(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            var email = qm.QueryEmail(phone);
        }

        private static void Example02()
        {
            MySqlConnection con =
                new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            Sample.Example02.QueryMember2 qm =
                new Sample.Example02.QueryMember2(con);

            var email = qm.QueryEmail(phone);
        }

        private static void Example03()
        {
            MySqlConnection con =
                new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            using (Sample.Example03.IMemberRepository rep =
                new Sample.Example03.MemberRepository(con))

            {
                Sample.Example03.QueryMember3 qm = new Sample.Example03.QueryMember3(rep);

                var email = qm.QueryEmail(phone);
            }
        }

        private static void Example04()
        {
            Sample.Example04.JKOSContext ctx = new Sample.Example04.JKOSContext();

            using (Sample.Example04.IMemberRepository rep = new MemberRepository(ctx))
            {
                Sample.Example04.QueryMember4 qm4 = new Sample.Example04.QueryMember4(rep);

                var email = qm4.QueryEmail("+886911506909");
            }
        }
    }
}
