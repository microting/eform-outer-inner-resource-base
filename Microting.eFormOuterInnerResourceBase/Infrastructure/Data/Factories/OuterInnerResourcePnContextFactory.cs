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

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Factories;

public class OuterInnerResourcePnContextFactory : IDesignTimeDbContextFactory<OuterInnerResourcePnDbContext>
{
    public OuterInnerResourcePnDbContext CreateDbContext(string[] args)
    {
        var defaultCs =
            "Server = localhost; port = 3306; Database = outer-inner-resource-pn; user = root; password = secretpassword; Convert Zero Datetime = true;";
        var optionsBuilder = new DbContextOptionsBuilder<OuterInnerResourcePnDbContext>();
        optionsBuilder.UseMySql(args.Any() ? args[0] : defaultCs, new MariaDbServerVersion(
                ServerVersion.AutoDetect(args.Any() ? args[0] : defaultCs)),
            builder => { builder.EnableRetryOnFailure(); });

        return new OuterInnerResourcePnDbContext(optionsBuilder.Options);
        // dotnet ef migrations add InitialCreate --project Microting.eFormOuterInnerResourceBase --startup-project DBMigrator
    }
}