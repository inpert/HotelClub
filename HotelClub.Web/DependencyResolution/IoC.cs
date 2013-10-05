// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Data.Entity;
using HotelClub.Core;
using HotelClub.Data;
using HotelClub.Repository;
using HotelClub.Interface;
using HotelClub.Web.Data;
using StructureMap;

namespace HotelClub.Web.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                        scan.AssemblyContainingType<MainContext>();             // Data
                                        scan.AssemblyContainingType<Repository<BaseDataModel>>();      // Repository
                                        scan.AssemblyContainingType<UserProfile>();             // Core
                                    });
                            x.For<IRepository<Customer>>().Singleton().Use<Repository<Customer>>();
                            x.For<IRepository<Address>>().Singleton().Use<Repository<Address>>();
                            x.For<IRepository<Hotel>>().Singleton().Use<Repository<Hotel>>();
                            x.For<IRepository<Fee>>().Singleton().Use<Repository<Fee>>();
                            x.For<IRepository<Country>>().Singleton().Use<Repository<Country>>();
                            x.For<IRepository<UserProfile>>().Singleton().Use<Repository<UserProfile>>();
                            x.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<MainContext>();
                            x.For<IApplicationUnit>().Singleton().Use<ApplicationUnit>();
                        });
            return ObjectFactory.Container;
        }
    }
}