﻿var config = {
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
    authority: "https://localhost:44397",
    client_id: "client_id_js",
    redirect_uri: "https://localhost:44374/Home/SignIn",
    response_type: "id_token token",
    scope: "openid rc.scope ApiOne ApiTwo"
};

var userManager = new Oidc.UserManager(config);

var signIn = function () {
    userManager.signinRedirect();
}

userManager.getUser().then(user => {
    console.log("user:", user);
    if (user) {
        axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
    }
});

var callApi = function () {
    axios.get("https://localhost:44319/secret")
        .then(res => {
            console.log(res);
        })
}