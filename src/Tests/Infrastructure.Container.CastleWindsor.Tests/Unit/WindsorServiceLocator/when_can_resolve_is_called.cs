using System;
using Castle.Windsor;
using Machine.Specifications;

namespace Infrastructure.Container.CastleWindsor.Tests.Unit.WindsorServiceLocator {
    [Subject(typeof(CastleWindsor.WindsorServiceLocator))]
    public class when_can_resolve_is_called {
        static CastleWindsor.WindsorServiceLocator serviceLocator;

        Establish context = () => { serviceLocator = new CastleWindsor.WindsorServiceLocator(new WindsorContainer()); };

        Because of = () => {
            serviceLocator.Register(typeof(ITest), typeof(Test));
            serviceLocator.Register(typeof(ITest), typeof(Test2));
            serviceLocator.LogRegisteredComponents();
        };

        It should_be_able_to_resolve_interface_type = () => serviceLocator.CanResolve(typeof(ITest)).ShouldBeTrue();

        It should_be_able_to_resolve_interface_type_with_registered_key =
            () => serviceLocator.CanResolve(typeof(ITest), typeof(Test).FullName).ShouldBeTrue();

        It should_not_be_able_to_resolve_bad_interface = () => serviceLocator.CanResolve(typeof(IUnregistered)).ShouldBeFalse();
        It should_not_be_able_to_resolve_interface_key_with_bad_key = () => serviceLocator.CanResolve(typeof(ITest), "xxx").ShouldBeFalse();


        public interface ITest {
            string Name {
                get;
            }
        }

        public interface IUnregistered {}

        public class Test : ITest {
            public string Name {
                get {
                    throw new NotImplementedException();
                }
            }
        }

        public class Test2 : ITest {
            public string Name {
                get {
                    throw new NotImplementedException();
                }
            }
        }
    }
}