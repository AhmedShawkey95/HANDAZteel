﻿#region Copyright
/*Copyright (C) 2015 Wosad Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Wosad.Common.Mathematics;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Wosad.Common.Section
{
    /// <summary>
    /// Full width rectangular part from which CompoundShape section is built
    /// </summary>
    /// 
    [DataContract]  [Serializable]  [XmlSerializerFormat]
    [KnownType(typeof(CompoundShapePart))]
    public class CompoundShapePart
    {
        /// <summary>
        /// Width
        /// </summary>

        private double _b;
       [DataMember, XmlAttribute]
        public double b
        {
            get { 
                double width = GetWidth();
                return width; }
            set { _b = value; }
        }

        public virtual double GetWidth()
        {
 	        return _b;
        }
        
        
        /// <summary>
        /// Height
        /// </summary>

        private double _h;
       [DataMember, XmlAttribute]
        public double h
        {
            get {
                double height = GetHeight();
                return height; 
            }
            set { _h = value; }
        }

        public virtual double GetHeight()
        {
            return _h;
        }

        /// <summary>
        /// Actual Height
        /// </summary>

        private double _h_a;
       [DataMember, XmlAttribute]
        public double h_a
        {
            get
            {
                double heightActual = GetActualHeight();
                return heightActual;
            }
            internal set { }

        }

        protected virtual double GetActualHeight()
        {
            return _h;
        }
        
        private Point2D insertionPoint;

        /// <summary>
        /// Insertion point and centroid coinside for a rectangular shape but could be different for other types of shapes
        /// </summary>
       [DataMember, XmlAttribute]
        /// 
        public Point2D InsertionPoint
        {
            get {
                return insertionPoint; }
            set { insertionPoint = value; }
        }

        private Point2D centroid;
       [DataMember, XmlAttribute]
        public Point2D Centroid
        {
            get {
                centroid = GetCentroid();
                return centroid; }
            set { centroid = value; }
        }


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="b">Width</param>
        /// <param name="h">Height</param>
        public CompoundShapePart(double b, double h, Point2D InsertionPoint)
        {
            this.b = b;
            this.h = h;
            this.InsertionPoint = InsertionPoint;
        }
        public CompoundShapePart()
        {

        }

        public virtual double GetArea()
        {
            return b * h;
        }
        public virtual double GetMomentOfInertia() 
        {
            return b * Math.Pow(h, 3) / 12.0;
        }

        //public virtual double GetMomentOfInertiaY()
        //{
        //    return h * Math.Pow(b, 3) / 12.0;
        //}

        public virtual Point2D GetCentroid()
        {
            return insertionPoint;
        }
       [DataMember, XmlAttribute]


        public double Ymax
        {
            get { return GetYmax(); }
            internal set { }

        }
       [DataMember, XmlAttribute]


        public double Ymin
        {
            get { return GetYmin(); }
            internal set { }

        }

        protected virtual double GetYmax()
        {
            return this.InsertionPoint.Y+h/2;
        }
        protected virtual double GetYmin()
        {
            return this.InsertionPoint.Y - h / 2;
        }
    }
}
