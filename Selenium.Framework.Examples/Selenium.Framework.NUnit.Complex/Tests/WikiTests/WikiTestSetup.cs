using Selenium.Framework.NUnit.Complex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework.NUnit.Complex.Tests.WikiTests;

public class WikiTestSetup : BaseTestSetup
{
    protected new WikiTestEntity Entity => BaseTestSetup.Entity as WikiTestEntity
        ?? throw new ArgumentNullException($"Unable to cast the entity as a {nameof(WikiTestEntity)}");
}
