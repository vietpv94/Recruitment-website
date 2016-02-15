<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["UsersOnline"] = 1;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Session["Login"] = null;
        Session["User"] = null;
        Session["Recruitor"] = null;
        Application["UsersOnline"] = (int)Application["UsersOnline"] + 1;
        Session.Timeout = 60;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Session["Login"] = null;
        Session["User"] = null;
        Session["Recruitor"] = null;
        Application["UsersOnline"] = (int)Application["UsersOnline"] - 1;
    }
       
</script>
