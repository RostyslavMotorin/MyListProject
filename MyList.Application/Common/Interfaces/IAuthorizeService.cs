using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models;

namespace MyList.Application.Common.Interfaces
{
    public interface IAuthorizeService
    {
        Task<IdentityLoginDto> RegisterUser(RegisterModel model);
        Task<IdentityLoginDto> LogInUser(LoginModel model);
    }

    public interface Velance
    {
        public int Speed { get; set; }
        void GO();
        void Stop();

    }

    public class Fly : Velance
    {
        public int Speed { get; set; }
        public void GO()
        {
            //fly logic
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
    public class car : Fly
    {
      
    }

    public class CatsFAmily
    {
       public void test(){}
       public void test(car te, car tes, car texs, car tesv, car tesc, car tess) {}
       public void test(int te){}
       public void test(bool te){}
    }
    public class Lion: CatsFAmily{}

    class prog
    {
        void te()
        {
            Lion lion1 = new Lion();
            CatsFAmily lion2 = new Lion();
        }


    }
}
