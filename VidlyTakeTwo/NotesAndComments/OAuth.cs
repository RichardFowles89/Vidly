namespace VidlyTakeTwo.NotesAndComments
{
    public class OAuth
    {/*
                    OPEN AUTHORISATION

Here's how it works: First we register our app with ID provider (let's userFacebook) to create a partnership.
The ID provider will give us a API key and a secret (like a username and password). This is what is used
to "talk" to the social media provider.

So when someone tries to login into Vidly using an ID provider, they are re-directed to FB along with 
the API key and secret so FB knows the request is coming from Vidly. This needs to be done over HTTPS
to ensure the info is kept safe. 

Once the user has logged into FB, FB sends them back to Vidly with an authorisation token. FB knows
Vidly's address because we registered it with FB at the beginning. The authorisation token tells Vidly
that FB successfully authenticated the user. 

Vidly then sends the token, API key and secret BACK to FB. We do this because a malicious user could
send a random token to Vidly. FB will then send us an access token, and with this Vidly can access
the parts of the user's profile we have permission to access. 


                HOW TO DO 

You need to enable SSL. Copy the HTTPS url into the Web tab of the project's 'Properties'. 

IIS will generate a self-signed certificate (a dummy certificate). For a real app we would need to get
a certificate from a certification authority. 

To register with FB, go to developers.facebook.com

You add the API key and secret to Startup.Auth in App_Start.

IMPORTANT - in developer.facebook.com, you need to set 'Valid OAuth redirect URIs' to the app's url +
"signin-facebook". E.g. https://localhost:44377/signin-facebook. I think this is the same with other 
ID providers. 
    */
    }
}