using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DepencencyResolvers
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
        //AutoBussinesModule ile çözemediğimiz bağımlılıkları çözebilmek amacıyla bu kodu yazıyoruz.
    }
}
