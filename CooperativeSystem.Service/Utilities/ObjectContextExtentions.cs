using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Utilities
{
    internal class ObjectContextExtentions
    {
        //internal static void CancelChanges(ObjectContext context, EntityObject entity)
        //{

        //    //if object is deleted we refresh it then we will refresh everyobejct that refers to it.
        //    if (entity.EntityState == EntityState.Deleted)
        //    {
        //        context.Refresh(RefreshMode.StoreWins, entity);
        //    }

        //    //get the entry
        //    var entry = context.ObjectStateManager.GetObjectStateEntry(entity.EntityKey);

        //    //revert properties
        //    if (entity.EntityState == EntityState.Modified)
        //    {
        //        // Scalar value
        //        for (int i = 0; i < entry.OriginalValues.FieldCount; i++)
        //        {
        //            if (!entry.CurrentValues[i].Equals(entry.OriginalValues[i]))
        //            {
        //                entry.CurrentValues.SetValue(i, entry.OriginalValues[i]);

        //                //last fix here i need to notify property change on the entity

        //            }

        //        }
        //    }

        //    //1 to 1 relation
        //    IEnumerable<ObjectStateEntry> added_rels = context.GetRelationshipsForKey(entity.EntityKey, EntityState.Added);
        //    IEnumerable<ObjectStateEntry> deleted_rels = context.GetRelationshipsForKey(entity.EntityKey, EntityState.Deleted);
        //    IEnumerable<IRelatedEnd> relEnds = ((IEntityWithRelationships)entity).RelationshipManager.GetAllRelatedEnds();

        //    foreach (ObjectStateEntry addedEntry in added_rels)
        //    {
        //        // corresponding deleted
        //        IEnumerable<ObjectStateEntry> relatedDeletedEntries = from d in deleted_rels
        //                                                              where d.EntitySet == addedEntry.EntitySet
        //                                                              select d;
        //        //any related else we skip to next iteration
        //        if (relatedDeletedEntries.Count() == 0) continue;

        //        //otherwise we fetch the entry.
        //        ObjectStateEntry relatedDeleted = relatedDeletedEntries.First();

        //        // corresponding relationships
        //        IEnumerable<IRelatedEnd> relatedRelationShips = from r in relEnds
        //                                                        where r.Contains(addedEntry.OtherEndKey(entity.EntityKey))
        //                                                        select r;

        //        //any related else we skip to next iteration
        //        //if (relatedRelationShips.Count() == 0) continue;
        //        if ((relatedRelationShips.Count() == 0) || (relatedRelationShips.OfType<EntityReference>().Count() == 0)) 
        //            continue;


        //        //otherwise we fetch the relationDnd
        //        IRelatedEnd relatedEnd = relatedRelationShips.OfType<EntityReference>().First();

        //        // get the old key
        //        EntityKey oldKey = (EntityKey)(relatedDeleted.OriginalValues[0]);

        //        try
        //        {
        //            //fetch the entity object
        //            Object obj = null;
        //            if (context.TryGetObjectByKey(oldKey, out obj))
        //            {
        //                EntityObject entityObj = obj as EntityObject;
        //                //the obejct is deleted we cancel it changes.
        //                if (entityObj.EntityState == EntityState.Deleted)
        //                {
        //                    CancelChanges(context, entityObj);
        //                }
        //                // restore the key and the relationship
        //                relatedEnd.SetEntityKey(oldKey);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            throw new CancelChangesException(e.Message);
        //        }
        //    }

        //    //revert added relation 1 to M or M to M
        //    IEnumerable<IGrouping<IRelatedEnd, ObjectStateEntry>> addedRelations = context.GetRelationshipsByRelatedEnd(entity, EntityState.Added);

        //    //for each relationend
        //    foreach (IGrouping<IRelatedEnd, ObjectStateEntry> relatedEnd in addedRelations)
        //    {
        //        //for each change in the relation end
        //        foreach (ObjectStateEntry relationShip in relatedEnd)
        //        {
        //            //get the key
        //            EntityKey endKey = (EntityKey)relationShip.UsableValues()[0];
        //            EntityKey sourceKey = (EntityKey)relationShip.UsableValues()[1];

        //            //the end key is the entities related to ours
        //            endKey = endKey == entity.EntityKey ? sourceKey : endKey;

        //            //fetch the entity object
        //            Object obj = null;
        //            if (context.TryGetObjectByKey(endKey, out obj))
        //            {
        //                try
        //                {
        //                    //if the object is deleted we cancel its changes
        //                    EntityObject entityObj = obj as EntityObject;
        //                    if (entityObj.EntityState == EntityState.Deleted)
        //                    {
        //                        CancelChanges(context, entityObj);
        //                    }

        //                    //re-add it
        //                    //if the object is deleted it will throw an exception
        //                    relatedEnd.Key.Remove(obj as IEntityWithRelationships);
        //                }
        //                catch (Exception e)
        //                {
        //                    throw new CancelChangesException(e.Message);
        //                }

        //            }
        //        }
        //    }

        //    //revert deleted relation 1 to M or M to M                                        
        //    IEnumerable<IGrouping<IRelatedEnd, ObjectStateEntry>> deletedRelations = context.GetRelationshipsByRelatedEnd(entity, EntityState.Deleted);

        //    //for each relationend
        //    foreach (IGrouping<IRelatedEnd, ObjectStateEntry> relatedEnd in deletedRelations)
        //    {
        //        //for each change in the relation end
        //        foreach (ObjectStateEntry relationShip in relatedEnd)
        //        {
        //            //get the key
        //            EntityKey endKey = (EntityKey)relationShip.UsableValues()[0];
        //            EntityKey sourceKey = (EntityKey)relationShip.UsableValues()[1];

        //            //the end eky is the entities related to ours
        //            endKey = endKey == entity.EntityKey ? sourceKey : endKey;

        //            //fetch the entity object
        //            Object obj = null;
        //            if (context.TryGetObjectByKey(endKey, out obj))
        //            {
        //                try
        //                {
        //                    //if the object is deleted we cancel its changes
        //                    EntityObject entityObj = obj as EntityObject;
        //                    if (entityObj.EntityState == EntityState.Deleted)
        //                    {
        //                        CancelChanges(context, entityObj);
        //                    }

        //                    //re-add it
        //                    relatedEnd.Key.Add(obj as IEntityWithRelationships);
        //                }
        //                catch (Exception e)
        //                {
        //                    throw new CancelChangesException(e.Message);
        //                }

        //            }
        //        }
        //    }

        //    //if the object was added we simply delete it
        //    if (entity.EntityState == EntityState.Added)
        //    {
        //        context.DeleteObject(entity);
        //    }

        //    entry.AcceptChanges();
        //}
    }
}
