// ***********************************************************************************
// Copyright 2019 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
// ***********************************************************************************
namespace Butter.Validation.Rules
{
    using System.Collections.Generic;
    using System.Linq;
    using Grammar;
    using NRules.Fluent.Dsl;

    [Tag("FieldValidation")]
    public class NullFieldRule :
        Rule
    {
        public override void Define()
        {
            IEnumerable<Field> fields = null;
            
            Name(nameof(NullFieldRule));

            When()
                .Query(() => fields, x =>
                    x.Match<Field>(f => f == null)
                        .Collect()
                        .Where(f => f.Any()));

            Then()
                .Do(x => x.NoOp());
        }
    }
}