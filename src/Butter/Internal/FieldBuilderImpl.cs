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
namespace Butter.Internal
{
    using Grammar;

    class FieldBuilderImpl :
        FieldBuilder
    {
        string _id;
        FieldDataType _dataType;
        bool _nullable;

        public FieldBuilder Id(string id)
        {
            _id = id;
            
            return this;
        }

        public FieldBuilder DataType(FieldDataType dataType)
        {
            _dataType = dataType;
            
            return this;
        }

        public FieldBuilder IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public Field Build() => new FieldImpl(_id, _dataType, _nullable);
    }
}