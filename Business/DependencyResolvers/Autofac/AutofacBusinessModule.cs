using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<ProductColorManager>().As<IProductColorService>().SingleInstance();
            builder.RegisterType<EfProductColorDal>().As<IProductColorDal>().SingleInstance();

            builder.RegisterType<FootManager>().As<IFootService>().SingleInstance();
            builder.RegisterType<EfFootDal>().As<IFootDal>();

            builder.RegisterType<FootColorManager>().As<IFootColorService>().SingleInstance();
            builder.RegisterType<EfFootColorDal>().As<IFootColorDal>();

            builder.RegisterType<FabricManager>().As<IFabricService>().SingleInstance();
            builder.RegisterType<EfFabricDal>().As<IFabricDal>().SingleInstance();

            builder.RegisterType<FabricColorManager>().As<IFabricColorService>().SingleInstance();
            builder.RegisterType<EfFabricColorDal>().As<IFabricColorDal>().SingleInstance();

            builder.RegisterType<TableColorManager>().As<ITableColorService>().SingleInstance();
            builder.RegisterType<EfTableColorDal>().As<ITableColorDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<ProformaManager>().As<IProformaService>().SingleInstance();
            builder.RegisterType<EfProformaDal>().As<IProformaDal>();

            builder.RegisterType<ProductionManager>().As<IProductionService>().SingleInstance();
            builder.RegisterType<EfProductionDal>().As<IProductionDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
