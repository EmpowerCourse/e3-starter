using NHibernate.Event;
using NHibernate.Persister.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3Starter.Persistence.NHIbernate.Listeners;

public class AuditEventListener : IPreInsertEventListener
{
    public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public bool OnPreInsert(PreInsertEvent @event)
    {
        //if (!(@event.Entity is UserManagedModelBase modelBase))
        //    return false;

        //var time = DateTime.UtcNow;
        //Set(@event.Persister, @event.State, "CreatedAt", time);
        //modelBase.CreatedAt = time;
        return false;
    }

    private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
    {
        //var index = Array.IndexOf(persister.PropertyNames, propertyName);
        //if (index == -1)
        //    return;
        //state[index] = value;
    }
}
