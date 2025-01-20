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
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Factories;
using NUnit.Framework;

namespace eFormMachineAreaDotnet.Tests;

[TestFixture]
public abstract class DbTestFixture
{
    [SetUp]
    public void Setup()
    {
        _connectionString =
            @"Server = localhost; port = 3306; Database = outer-inner-resource-tests; user = root; password = secretpassword; Convert Zero Datetime = true;";

        GetContext(_connectionString);

        DbContext.Database.SetCommandTimeout(300);

        try
        {
            ClearDb();
        }
        catch
        {
            DbContext.Database.Migrate();
        }

        DoSetup();
    }

    [TearDown]
    public void TearDown()
    {
        ClearDb();

        DbContext.Dispose();
    }

    protected OuterInnerResourcePnDbContext DbContext;
    private string _connectionString;

    private void GetContext(string connectionStr)
    {
        var contextFactory = new OuterInnerResourcePnContextFactory();
        DbContext = contextFactory.CreateDbContext(new[] { connectionStr });

        DbContext.Database.Migrate();
        DbContext.Database.EnsureCreated();
    }

    private void ClearDb()
    {
        var modelNames = new List<string>
        {
            "OuterResources",
            "OuterResourceVersions",
            "InnerResources",
            "InnerResourceVersions",
            "OuterInnerResources",
            "OuterInnerResourceVersions",
            "ResourceTimeRegistrations",
            "ResourceTimeRegistrationVersions",
            "PluginConfigurationValues",
            "PluginConfigurationValueVersions"
        };

        var firstRunNotDone = true;

        foreach (var modelName in modelNames)
            try
            {
                if (firstRunNotDone)
                    DbContext.Database.ExecuteSqlRaw(
                        $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `outer-inner-resource-tests`.`{modelName}`");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unknown database 'outer-inner-resource-tests'")
                    firstRunNotDone = false;
                else
                    Console.WriteLine(ex.Message);
            }
    }

    protected virtual void DoSetup()
    {
    }
}