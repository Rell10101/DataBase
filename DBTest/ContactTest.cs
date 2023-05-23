// автор: Самаев Антон ИВТ-21

using ContactListDB;
using System.Xml.Linq;

namespace DBTest
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void TestMethod_Constructor()
        {
            Contact f1 = new Contact("Anton", "Samaev", "89963112857", "anton@mail.ru");
            Assert.AreEqual("Anton", f1.name_get());
            Assert.AreEqual("Samaev", f1.surname_get());
            Assert.AreEqual("89963112857", f1.phone_get());
            Assert.AreEqual("anton@mail.ru", f1.email_get());

            Contact f2 = new Contact("Ivan", "Ivanov", "123456789", "ivanov@mail.ru");
            Assert.AreEqual("Ivan", f2.name_get());
            Assert.AreEqual("Ivanov", f2.surname_get());
            Assert.AreEqual("123456789", f2.phone_get());
            Assert.AreEqual("ivanov@mail.ru", f2.email_get());

            Contact f3 = new Contact("Sasha", "Petrov", "0987654321", "sasha@mail.ru");
            Assert.AreEqual("Sasha", f3.name_get());
            Assert.AreEqual("Petrov", f3.surname_get());
            Assert.AreEqual("0987654321", f3.phone_get());
            Assert.AreEqual("sasha@mail.ru", f3.email_get());
        }

        [TestMethod]
        public void TestMethod_set()
        {
            Contact f1 = new Contact();

            f1.name_set("Anton");
            Assert.AreEqual("Anton", f1.name_get());
            f1.surname_set("Samaev");
            Assert.AreEqual("Samaev", f1.surname_get());
            f1.phone_set("89963112857");
            Assert.AreEqual("89963112857", f1.phone_get());
            f1.email_set("anton@mail.ru");
            Assert.AreEqual("anton@mail.ru", f1.email_get());

            f1.name_set("Ivan");
            Assert.AreEqual("Ivan", f1.name_get());
            f1.surname_set("Ivanov");
            Assert.AreEqual("Ivanov", f1.surname_get());
            f1.phone_set("123456789");
            Assert.AreEqual("123456789", f1.phone_get());
            f1.email_set("ivanov@mail.ru");
            Assert.AreEqual("ivanov@mail.ru", f1.email_get());

            f1.name_set("Sasha");
            Assert.AreEqual("Sasha", f1.name_get());
            f1.surname_set("Petrov");
            Assert.AreEqual("Petrov", f1.surname_get());
            f1.phone_set("0987654321");
            Assert.AreEqual("0987654321", f1.phone_get());
            f1.email_set("sasha@mail.ru");
            Assert.AreEqual("sasha@mail.ru", f1.email_get());
        }
    }
}