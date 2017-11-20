package md5f54bf6ad248613857a792a9615fb192a;


public class PurchasePage
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TinderBayHistory.PurchasePage, TinderBayHistory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PurchasePage.class, __md_methods);
	}


	public PurchasePage () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PurchasePage.class)
			mono.android.TypeManager.Activate ("TinderBayHistory.PurchasePage, TinderBayHistory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
