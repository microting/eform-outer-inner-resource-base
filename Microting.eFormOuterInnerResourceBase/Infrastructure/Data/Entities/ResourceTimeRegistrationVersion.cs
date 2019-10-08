/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities
{
    public class ResourceTimeRegistrationVersion : BaseEntity
    {
        
        public int InnerResourceId { get; set; }
        
//        public virtual Machine Machine { get; set; }
        
        public int OuterResourceId { get; set; }
        
//        public virtual Area Area { get; set; }
        
        public DateTime DoneAt { get; set; }
        
        public int SDKCaseId { get; set; }
        
        public int SDKFieldValueId { get; set; }
        
        public int TimeInSeconds { get; set; }
        
        public int TimeInMinutes { get; set; }
        
        public int TimeInHours { get; set; }
        
        public int SDKSiteId { get; set; }
        
        [ForeignKey("MachineAreaTimeRegistration")]
        public int MachineAreaTimeRegistrationId { get; set; }
        
//        public virtual MachineAreaTimeRegistration MachineAreaTimeRegistration { get; set; }
    }
}