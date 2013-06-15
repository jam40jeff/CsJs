using System.Collections;
using System.Collections.Generic;
using System.Html;
using System.Linq;

namespace MorseCode.CsJs.UI
{
    public class Styles : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> _styleDictionary = new Dictionary<string, string>();

        private Element _element;

        public string this[string name]
        {
            get { return Get(name); }
            set { AddOrSet(name, value); }
        }

        public string Get(string name)
        {
            string value;
            _styleDictionary.TryGetValue(name, out value);
            return value;
        }

        public void AddOrSet(string name, string value)
        {
            if (_styleDictionary.ContainsKey(name))
            {
                _styleDictionary[name] = value;
                OnStyleChanged(name, value);
            }
            else
            {
                _styleDictionary.Add(name, value);
                OnStyleAdded(name, value);
            }
        }

        public void Remove(string name)
        {
            if (_styleDictionary.Remove(name))
            {
                OnStyleRemoved(name);
            }
        }

        protected virtual void OnStyleChanged(string name, string value)
        {
            if (_element != null)
            {
                _element.Style[name] = value;
            }
        }

        protected virtual void OnStyleAdded(string name, string value)
        {
            if (_element != null)
            {
                _element.Style[name] = value;
            }
        }

        protected virtual void OnStyleRemoved(string name)
        {
            if (_element != null)
            {
                _element.Style[name] = string.Empty;
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _styleDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AttachToElement(Element element)
        {
            if (_element != null)
            {
                DetachFromElement(_element, false);
            }

            _element = element;
            ClearElementStyles(_element);
            foreach (KeyValuePair<string, string> style in this)
            {
                _element.Style[style.Key] = style.Value;
            }
        }

        public void DetachFromElement(Element element, bool clearElementStyles)
        {
            if (clearElementStyles)
            {
                ClearElementStyles(_element);
            }
            _element = null;
        }

        private static void ClearElementStyles(Element element)
        {
            element.RemoveAttribute("style");
        }

        internal void ParseStyleString(string value)
        {
            IEnumerable<string> styles = value.Split(';').Select(s => s.Trim());
            foreach (string style in styles)
            {
                if (string.IsNullOrEmpty(style))
                {
                    continue;
                }
                string[] nameValuePair = style.Split(':').Select(s => s.Trim()).ToArray();
                if (nameValuePair.Length == 2)
                {
                    this[nameValuePair[0]] = nameValuePair[1];
                }
            }
        }
    }
}