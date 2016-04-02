using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Sereal
{
    public class DecoderOptions
    {
        private bool perlRefs = false;
        private bool perlAlias = false;
        private bool preserveUndef = false;
        private bool preferLatin1 = false;
        private bool refuseSnappy = false;
        private bool refuseObjects = false;
        private bool stripObjects = false;
        private ITypeMapper typeMapper = new DefaultTypeMapper();

        public bool GetPerlReferences()
        {
            return perlRefs;
        }

        public DecoderOptions PerlReferences(bool perlReferences)
        {
            perlRefs = perlReferences;
            return this;
        }

        public bool GetPerlAliases()
        {
            return perlAlias;
        }

        public DecoderOptions PerlAliases(bool perlAliases)
        {
            perlAlias = perlAliases;
            return this;
        }

        public bool GetPreserveUndef()
        {
            return preserveUndef;
        }

        public DecoderOptions PreserveUndef(bool preserveUndef)
        {
            this.preserveUndef = preserveUndef;
            return this;
        }

        public bool GetPreferLatin1()
        {
            return preferLatin1;
        }

        public DecoderOptions PreferLatin(bool preferLatin1)
        {
            this.preferLatin1 = preferLatin1;
            return this;
        }

        public bool GetRefuseSnappy()
        {
            return refuseSnappy;
        }

        public DecoderOptions RefuseSnappy(bool refuseSnappy)
        {
            this.refuseSnappy = refuseSnappy;
            return this;
        }

        public bool GetRefuseObjects()
        {
            return refuseObjects;
        }

        public DecoderOptions RefuseObjects(bool refuseObjects)
        {
            this.refuseObjects = refuseObjects;
            return this;
        }

        public bool GetStripObjects()
        {
            return stripObjects;
        }

        public DecoderOptions StripObjects(bool stripObjects)
        {
            this.stripObjects = stripObjects;
            return this;
        }

        public ITypeMapper GetTypeMapper()
        {
            return typeMapper;
        }

        public DecoderOptions TypeMapper(ITypeMapper typeMapper)
        {
            this.typeMapper = typeMapper;
            return this;
        }
    }
}
