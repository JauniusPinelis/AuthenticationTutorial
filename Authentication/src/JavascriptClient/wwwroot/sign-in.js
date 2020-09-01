var createState = function () {
    return "SessionValueMakeItAbitLongerasdsfdfdfdvfdfdflgfjklmlmlm";
}

var createNonce = function () {
    return "NonceValuefdffffffffffffffffffffffffffffgtggggtytytyytyt"
}


var signIn = function () {

    var redirectUri = "https://localhost:44374/SignIn";
    var responseType = "id_token%20token";
    var scope = "openid ApiOne";

    var authUrl = `/connect/authorize/callback?client_id=client_id_js?redirect_uri=${encodeURIComponent(redirectUri)}?response_type=${responseType}?scope=${encodeURIComponent(scope)}?nonce=${createNonce()}?state=${createState()}`;
    var returnUrl = encodeURIComponent(authUrl);

    console.log(authUrl);
    console.log(returnUrl);

    window.location.href =
        "https://localhost:44397/Auth/Login?ReturnUrl=" + returnUrl;
}