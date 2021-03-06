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
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Grammar;
    using Notification;

    class SchemaBuilderImpl :
        ISchemaBuilder
    {
        readonly List<Field> _fields = new List<Field>();
        readonly List<IObserver<NotificationContext>> _observers = new List<IObserver<NotificationContext>>();

        public ISchemaBuilder Field(string id, FieldDataType dataType, bool nullable = false)
        {
            _fields.Add(new FieldImpl(id, dataType, nullable));
            
            return this;
        }

        public ISchemaBuilder Field(string id, Action<DecimalFieldDefinition> definition, bool nullable = false)
        {
            var impl = new DecimalFieldDefinitionImpl();
            definition(impl);
            
            _fields.Add(new DecimalFieldImpl(id, impl.Scale.Value, impl.Precision.Value, nullable));
            
            return this;
        }

        public ISchemaBuilder Field(string id, IReadOnlyFieldList fields, bool nullable = false)
        {
            _fields.Add(new StructFieldImpl(id, fields, isNullable:nullable));
            
            return this;
        }

        public ISchemaBuilder RegisterObserver(IObserver<NotificationContext> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            
            return this;
        }

        public ISchema Build() => new Schema(_fields, _observers);


        class DecimalFieldDefinitionImpl :
            DecimalFieldDefinition
        {
            int _precision;
            int _scale;

            public Lazy<int> Scale { get; }
            public Lazy<int> Precision { get; }

            public DecimalFieldDefinitionImpl()
            {
                Scale = new Lazy<int>(() => _scale, LazyThreadSafetyMode.PublicationOnly);
                Precision = new Lazy<int>(() => _precision, LazyThreadSafetyMode.PublicationOnly);
            }

            public void SetScale(int scale)
            {
                _scale = scale;
            }

            public void SetPrecision(int precision)
            {
                _precision = precision;
            }
        }
    }
}