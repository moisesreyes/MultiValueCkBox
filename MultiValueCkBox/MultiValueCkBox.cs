/*
 * Created by SharpDevelop.
 * User: moisesreyes
 * Date: 07/09/2015
 * Time: 10:45 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace MultiValueCkBox
{
	/// <summary>
	/// Description of MultiValueCkBox.
	/// </summary>
	public class MultiValueCkBox : CheckBox
	{
		private string _CheckedValue ="";
		private string _UncheckedValue="";
		private string _CkValue="";
		
		public MultiValueCkBox()
		{
			this.Initialize();
		}
		
		#region MultiValueCkBox Methods
		//Here we initialize the control and add an event handler
		private void Initialize()
		{
			this.CheckStateChanged += new EventHandler(ThisCheckStateChanged);
			this.PerformLayout();
		}
		
		//Method to get the current value of the checkbox control
		public string GetValue()
		{
			if (this.Checked)
				return this.CheckedValue;
			else
				return this.UncheckedValue;
		}
		
		//Method to asign a given value to checkbox control.
		public void SetValue(string pValue)
		{
			if (pValue == this._CheckedValue)
				this.Checked = true;
			else
				this.Checked = false;
		}
		
		//Here we call the method GetValue everytime the state of the CheckBox control change
		public void ThisCheckStateChanged(object sender, EventArgs e)
		{
			this.GetValue();
		}
		#endregion
		
		#region MultiValueCkBox Properties
		[Category("Custom Properties")]
        [Description("Value when CheckBox is checked.")]
        public string CheckedValue
        {
        	get {return this._CheckedValue;}
        	set {this._CheckedValue = value;}
        }
        
        [Category("Custom Properties")]
        [Description("Value when CheckBox is unchecked.")]
        public string UncheckedValue
        {
        	get {return this._UncheckedValue;}
        	set {this._UncheckedValue = value;}
        }
        
        [Category("Custom Properties"),Browsable(false)]
        [Description("value to store into database.")]
        public string CkValue
        {
        	get 
        	{
        		if (this.Checked) 
        			return this._CheckedValue;
        		else
        			return this.UncheckedValue;
        	}
        	set 
        	{
        		this._CkValue = value;
        		if (this._CkValue == this.CheckedValue)
        			this.Checked = true;
        		else
        			this.Checked = false;
        	}
        }
		#endregion
	}
}