using Newtonsoft.Json;

namespace Consol.Classes
{
    public class Asosiyxizmat
    {
        private List<Contact> _contacts = new List<Contact>();
        private readonly string _filePath = "contacts.json";

        public Asosiyxizmat()
        {
            ContactniYuklash();
        }

    
        private void ContactniYuklash()
        {
            TryCatch.Handle(() =>
            {
                if (File.Exists(_filePath))
                {
                    var json = File.ReadAllText(_filePath);
                    _contacts = JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
                }
            });
        }

        private void ContacniSaqlash()
        {
            TryCatch.Handle(() =>
            {
                var json = JsonConvert.SerializeObject(_contacts);
                File.WriteAllText(_filePath, json);
            });
        }

        public void ContactQoshish(Contact contact)
        {
            _contacts.Add(contact);
            ContacniSaqlash();
            LoggingBroker.LogInfo("Kontakt muvaffaqiyatli qo'shildi.");
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                ContacniSaqlash();
                LoggingBroker.LogInfo("Kontakt muvaffaqiyatli o'chirildi.");
            }
        }

        public List<Contact> GetAllContacts() => _contacts;

        public Contact SearchContact(string name) =>
        _contacts.Find(c => c.Ism?.Equals(name, StringComparison.OrdinalIgnoreCase) ?? false) ?? new Contact();
    }
    
}