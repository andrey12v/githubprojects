using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ParPercent
{
    private string coName; 
    private string itemNumber;
    private string amountInStock;
    private string onOrder;
    private string par;

    public ParPercent() { }


    # region properties

    public string CoName
    {
        get
        {
            return this.coName;
        }
        set
        {
            this.coName = value;
        }
    }


    public string ItemNumber
    {
        get
        {
            return this.itemNumber;
        }
        set
        {
            this.itemNumber = value;
        }
    }


    public string AmountInStock
    {
        get
        {
            return this.amountInStock;
        }
        set
        {
            this.amountInStock = value;
        }
    }

    public string OnOrder
    {
        get
        {
            return this.onOrder;
        }
        set
        {
            this.onOrder = value;
        }
    }

    public string Par
    {
        get
        {
            return this.par;
        }
        set
        {
            this.par = value;
        }
    }

    #endregion

}

