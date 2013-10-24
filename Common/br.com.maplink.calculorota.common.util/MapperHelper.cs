using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace br.com.maplink.calculorota.common.util
{
    public class MapperHelper<TS, TD>
    {
        private static IMappingExpression<TS, TD> _mappings = null;
        private static IMappingExpression<TD, TS> _revmappgins = null;

        public MapperHelper()
        {
            if (_mappings == null)
            {
                _mappings = Mapper.CreateMap<TS, TD>();
            }
        }

        private void PopulateReverseMap()
        {
            if (_revmappgins == null)
            {
                _revmappgins = Mapper.CreateMap<TD, TS>();
            }
        }

        public TD Convert(TS f)
        {
            return Mapper.Map<TD>(f);
        }

        public TS ReverseConvert(TD d)
        {
            PopulateReverseMap();
            return Mapper.Map<TS>(d);
        }

        public IList<TD> ConvertToList(IList<TS> f)
        {
            return Mapper.Map<IList<TS>, IList<TD>>(f);
        }

        public IList<TS> ReverseConvertToList(IList<TD> d)
        {
            PopulateReverseMap();
            return Mapper.Map<IList<TD>, IList<TS>>(d);
        }

        public IQueryable<TD> ConvertToQueryable(IQueryable<TS> f)
        {
            return Mapper.Map<IQueryable<TS>, IQueryable<TD>>(f);
        }

        public TD CustomConvert(TS f)
        {
            //TODO: implementar esquema...
            throw new NotImplementedException();
        }
    }
}
