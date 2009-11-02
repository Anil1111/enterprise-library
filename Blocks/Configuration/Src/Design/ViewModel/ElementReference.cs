﻿//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Core
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console.Wpf.ViewModel.Services;
using System.ComponentModel;
using Console.Wpf.ViewModel;

namespace Console.Wpf
{
    public abstract class ElementReference : IDisposable
    {
        ElementViewModel element;
        PropertyChangedEventHandler elementPropertyChanged;
        EventHandler elementDeleted;

        protected ElementReference(ElementViewModel element)
        {
            this.element = element;
            this.elementPropertyChanged = new PropertyChangedEventHandler(element_PropertyChanged);
            this.elementDeleted = new EventHandler(element_Deleted);
            
            if (element != null)
            {
                InitializeChangeEvents(element);
            }
        }

        public ElementViewModel Element
        {
            get { return element; }
        }

        protected virtual void OnElementFound(ElementViewModel element)
        {
            this.element = element;

            InitializeChangeEvents(element);

            var handler = ElementFound;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void InitializeChangeEvents(ElementViewModel element)
        {
            element.PropertyChanged += elementPropertyChanged;
            element.Deleted += elementDeleted;
        }

        void element_Deleted(object sender, EventArgs e)
        {
            OnElementDeleted();
        }

        void element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Path")
            {
                var handler = PathChanged;
                if (handler != null)
                {
                    handler(sender, new PropertyValueChangedEventArgs<string>(((ElementViewModel)sender).Path));
                }
            }

            if (e.PropertyName == "Name")
            {
                var handler = NameChanged;
                if (handler != null)
                {
                    handler(sender, new PropertyValueChangedEventArgs<string>(((ElementViewModel)sender).Name));
                }
            }
        }

        public event EventHandler ElementFound;

        protected virtual void OnElementDeleted()
        {
            element.PropertyChanged -= elementPropertyChanged;
            element.Deleted -= elementDeleted;

            this.element = null;

            var handler = ElementDeleted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler ElementDeleted;

        public event PropertyValueChangedEventHandler<string> NameChanged;

        public event PropertyValueChangedEventHandler<string> PathChanged;

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (element != null)
                {
                    element.PropertyChanged -= elementPropertyChanged;
                    element.Deleted -= elementDeleted;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }

    public delegate void PropertyValueChangedEventHandler<T>(object sender, PropertyValueChangedEventArgs<T> args);

    public class PropertyValueChangedEventArgs<T> : EventArgs
    {
        readonly T value;
        public PropertyValueChangedEventArgs(T value)
        {
            this.value = value;
        }

        public T Value { get { return value; } }
    }
}