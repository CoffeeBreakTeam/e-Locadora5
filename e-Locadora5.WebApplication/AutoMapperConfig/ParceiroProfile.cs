using AutoMapper;
using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static e_Locadora5.WebApplication.ViewModels.ParceiroViewModel;

namespace e_Locadora5.WebApplication.AutoMapperConfig
{
    public class ParceiroProfile : Profile
    {
        public ParceiroProfile(){
            ConfigurarConversaoDeDominioParaVM();

            ConfigurarConversaoDeVMParaDominio();
        }

        private void ConfigurarConversaoDeVMParaDominio()
        {
            CreateMap<ParceiroCreateViewModel, Parceiro>();
            CreateMap<ParceiroEditViewModel, Parceiro>();
        }

        private void ConfigurarConversaoDeDominioParaVM()
        {
            CreateMap<List<Parceiro>, ParceiroIndexViewModel>().ForMember(dest => dest.registros, opt => opt.MapFrom(a => a));
            
            CreateMap<Parceiro, ParceiroEditViewModel>();
            CreateMap<Parceiro, ParceiroDeleteViewModel>();
            CreateMap<Parceiro, ParceiroDetailsViewModel>();
            CreateMap<Parceiro, ParceiroListViewModel>();           
        }
    }
}
