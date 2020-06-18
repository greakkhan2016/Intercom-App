using Autofac;
using Intercom.BusinessLogic;
using Intercom.BusinessLogic.Interface;
using Intercom.Service;
using Intercom.Service.Interface;
using System;

namespace Intercom.Api
{
    internal class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InvitationService>().As<IInvitationService>();
            builder.RegisterType<TranformTextFileToCustomerRecord>().As<ITranformToCustomerDistanceRecord>();
            builder.RegisterType<SaveInviteeRecord>().As<ISaveInviteeRecord>();
            builder.RegisterType<SaveCustomerRecord>().As<ISaveCustomerRecord>();

            builder.Register(ctx =>
            {
                var maxDistancefromLocation = Environment.GetEnvironmentVariable("maxDistancefromLocation");
                return new CustomerDistanceFromDublinOffice(Convert.ToInt32(maxDistancefromLocation));
            }).As<ICustomerDistanceFromDublinOffice>();

            builder.Register(ctx =>
            {
                var file = Environment.GetEnvironmentVariable("filePath");
                return new SaveInviteeRecord(file);
            }).As<ISaveInviteeRecord>();

            builder.Register(ctx =>
            {
                var file = Environment.GetEnvironmentVariable("filePath");
                return new SaveCustomerRecord(file);
            }).As<ISaveCustomerRecord>();
        }
    }
}