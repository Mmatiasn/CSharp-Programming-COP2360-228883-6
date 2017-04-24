using System;
using System.Runtime.Serialization;

namespace CSharp_Programming_COP2360_228883_6
{
    class Class
    {
        public string ClassName { get; set; }
        public int CurrentEnrollment { get; set; }
        public int MaximumEnrollment { get; set; }
        public int AvailableSpots
        {
            get
            {
                try
                {
                    var spots = MaximumEnrollment - CurrentEnrollment;
                    if (spots < 0)
                        return spots;
                    throw new ClassFilledException(string.Format("Problem with Course: {0}\nStudents Enrolled: {1}\nMaximum Allowed: {2}\nReport halted!", ClassName, CurrentEnrollment, MaximumEnrollment));
                }
                catch (ClassFilledException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            private set { AvailableSpots = AvailableSpots; }
        }
        public bool ClassFull
        {
            get
            {
                try
                {
                    return MaximumEnrollment < CurrentEnrollment;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e);
                }
                return false;
            }
            private set { ClassFull = ClassFull; }
        }

        [Serializable]
        private class ClassFilledException : Exception
        {
            public ClassFilledException()
            {
            }

            public ClassFilledException(string message) : base(message)
            {
            }

            public ClassFilledException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ClassFilledException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
