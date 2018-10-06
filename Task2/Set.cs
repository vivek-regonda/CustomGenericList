using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;


namespace Task2
{
    public class Set<T>
    {

        Object data;
        Set<T> next;
        Set<T> current = null;
        Set<T> head = null;


        public void Add(Object data)
        {
            if (current == null)
            {
                Set<T> temp = new Set<T>();
                temp.data = data;
                temp.next = null;

                current = temp;
                head = temp;
            }

            else
            {
               
                int IntObject = (int) data.GetType().GetProperty("Id").GetValue(data, null);
                bool IsDuplicateId = Find(IntObject);
                bool IsDuplicateRecord = Find(data);
                if (IsDuplicateId == false&&IsDuplicateRecord==false)
                {
                    Set<T> temp = new Set<T>();
                    temp.data = data;
                    temp.next = null;
                    current.next = temp;
                    current = temp;
                }
                else if (IsDuplicateId == true)
                {
                    throw new DuplicateRecordInsertionException("Trying to insert duplicate record, as the record already Exists");
                }

            }

        }


        public void PrintList()
        {

            Set<T> temp = head;


            while (temp.next != null)
            {

                Console.WriteLine(temp.data);
                temp = temp.next;

            }
            Console.WriteLine(temp.data);

        }



        public void RemoveAtIndex(int index)
        {
            Set<T> temp = head;
            Set<T> prev = head;
            int i = 0;
            while (temp != null)
            {
                if (i > 0)
                {

                    if (i == index)
                    {
                        prev.next = temp.next;
                        temp.next = null;
                    }

                    prev = prev.next;
                }

                else
                {

                    if (i == index)
                    {
                        head = head.next;
                        temp.next = null;

                    }

                }

                temp = temp.next;
                i++;

            }
        }
        

        public bool Find(Object o)
        {
            Set<T> temp = head;
            bool found = false;

            if (temp == null)
            {
                throw new NoRecordException("no records at all");
            }



            while (temp != null)
            {
                int IntObject = (int)temp.data.GetType().GetProperty("Id").GetValue(temp.data, null);
                string StrObject = (string)temp.data.GetType().GetProperty("Name").GetValue(temp.data, null);

                if (o.GetType() == typeof(int))
                {
                    if (o.Equals(IntObject))
                    {
                        Console.WriteLine("found " + IntObject + " with name -->" + temp.data.GetType().GetProperty("Name").GetValue(temp.data, null));
                        found = true;
                        break;
                    }
                }
                else if (o.GetType() == typeof(string))
                {
                    if (o.Equals(StrObject))
                    {
                        Console.WriteLine("found " + StrObject + " with Id -->" + temp.data.GetType().GetProperty("Id").GetValue(temp.data, null));
                        found = true;
                        break;
                    }
                }

                else if (o.GetType() == typeof(Customer))
                {
                    if (temp.data.Equals(o))
                    {
                        found = true;
                        break;
                    }

                }
                temp = temp.next;
            }
            return found;
            
            if (found == false)
            {
                throw new NoRecordException("no record found");
            }
            
        }


        public void Remove(Object o)
        {
            Set<T> temp = head;
            Set<T> prev = head;
            int i = 0;

            while (temp != null)
            {
                int IntObject = (int)temp.data.GetType().GetProperty("Id").GetValue(temp.data, null);
                string StrObject = (string)temp.data.GetType().GetProperty("Name").GetValue(temp.data, null);

                if (i > 0)
                {


                    if (o.GetType() == typeof(int))
                    {

                        if (o.Equals(IntObject))
                        {

                            Console.WriteLine("Removing record of Id " + IntObject);
                            prev.next = temp.next;
                            temp.next = null;
                            break;
                        }
                    }

                    else if (o.GetType() == typeof(string))
                    {
                        if (o.Equals(StrObject))
                        {
                            Console.WriteLine("Removing record of Name " + StrObject);
                            prev.next = temp.next;
                            temp.next = null;
                            break;
                        }
                    }
                    else if (o.GetType() == typeof(Customer))
                    {
                        if (temp.data.Equals(o))
                        {
                            Console.WriteLine("Removing record Id : " +IntObject+" Name : "+StrObject );
                            prev.next = temp.next;
                            temp.next = null;
                            break;
                        }

                    }
                    prev = prev.next;
                }
                else
                {
                    if (o.GetType() == typeof(int))
                    {

                        if (o.Equals(IntObject))
                        {
                            Console.WriteLine("Removing record of Id " + IntObject);
                            head = head.next;
                            temp.next = null;
                            break;
                        }
                    }

                    else if (o.GetType() == typeof(string))
                    {
                        if (o.Equals(StrObject))
                        {
                            Console.WriteLine("Removing record of Name " + StrObject);
                            head = head.next;
                            temp.next = null;
                            break;
                        }
                    }
                    else if (o.GetType() == typeof(Customer))
                    {
                        if (temp.data.Equals(o))
                        {
                            Console.WriteLine("Removing record of " + IntObject + " " + StrObject);
                            head = head.next;
                            temp.next = null;
                            break;
                        }
                    }
                    i++;
                }
                temp = temp.next;

            }

        }



       
        
        
        
        
        public int Indexer(Object o)
        {

            Set<T> temp = head;
            bool found = Find(o);
            int index=0;

            if (found == true)
            {
                while (temp != null)
                {
                    int IntObject = (int)temp.data.GetType().GetProperty("Id").GetValue(temp.data, null);
                    string StrObject = (string)temp.data.GetType().GetProperty("Name").GetValue(temp.data, null);

                    if (o.GetType() == typeof(int))
                    {
                        if (o.Equals(IntObject))
                        {
                            Console.WriteLine("Item with Id : "+IntObject+ " found at position "+index);

                            return index;
                        }
                    }
                    else if (o.GetType() == typeof(string))
                    {
                        if (o.Equals(StrObject))
                        {
                            Console.WriteLine("Item with name : " + StrObject + " found at position " + index);
                            return index;
                        }
                    }

                    else if (o.GetType() == typeof(Customer))
                    {
                        if (temp.data.Equals(o))
                        {
                            Console.WriteLine("Item with Id : " + IntObject + " with name "+StrObject+" found at position " + index);
                            return index;
                        }

                    }
                    temp = temp.next;
                    index++;
                }

            }
            else
            {
                throw new NoRecordException("Cannot Find Index As There is No Record"); 
            }

           

            return -1;
        }




        public Set<T> Sort()
        {

            Set<T> _current = head;
            Set<T> _previous = _current;
            Set<T> _min = _current;
            Set<T> _minPrevious = _min;
            Set<T> _sortedListHead = null;
            Set<T> _sortedListTail = _sortedListHead;
            Set<T> temp=head;


            while(temp!=null)
            {
                _current = head;
                _min = _current;
                _minPrevious = _min;
               
                int IntObject = (int)temp.data.GetType().GetProperty("Id").GetValue(temp.data, null);


                while (_current != null)
                {
                    int IntCurObject = (int)temp.data.GetType().GetProperty("Id").GetValue(temp.data, null);

                    if (IntCurObject<IntObject)
                    {
                        _min = _current;
                        _minPrevious = _previous;
                    }
                    _previous = _current;
                    _current = _current.next;
                }
               
                if (_min == head)
                {
                    head = head.next;
                }
                else if (_min.next == null) 
                {
                    _minPrevious.next = null;
                }
                else
                {
                    _minPrevious.next = _minPrevious.next.next;
                }
                
                if (_sortedListHead != null)
                {
                    _sortedListTail.next = _min;
                    _sortedListTail = _sortedListTail.next;
                }
                else
                {
                    _sortedListHead = _min;
                    _sortedListTail = _sortedListHead;
                }

                temp=temp.next;

            }



            head = _sortedListHead;

            return _sortedListHead;


        }










        /* public void Remove(Object Obj)
       {
           Set<T> temp = head;
           Set<T> prev = head;
           int i = 0;

           while (temp != null)
           {
               if (i > 0)
               {

                   if (temp.data.Equals(Obj))
                   {
                       prev.next = temp.next;
                       temp.next = null;
                   }

                   prev = prev.next;
               }
               else
               {

                   if (temp.data.Equals(Obj))
                   {
                       head = head.next;
                       temp.next = null;

                   }

               }
               temp = temp.next;

               i++;

           }

       }*/


        /* public Boolean Find(Object Obj)
         {
             Set<T> temp = head;

             while (temp.next != null)
             {

                 if (temp.data.Equals(Obj))
                 {
                     return true;
                 }
               
                 temp = temp.next;
               
             }
             if (temp.data.Equals(Obj))
             {
                 return true;
             }

             return false;
         }

          */




    }



}