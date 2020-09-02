var config = {
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

var refreshing = false;

axios.interceptors.response.use(
    function (response) {
    return response;
    },
    function (error) {
        console.log("axios error:", error.response);

        var axiosConfig = error.response.config;

        // if error response is 401 try to refresh token
        if (error.response.status === 401) {

            if (!refreshing) {
                refreshing = true;

                userManager.signinSilent().then(user => {
                    console.log("new user:", user);

                    axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
                    axiosConfig.headers["Authorization"] = "Bearer " + user.access_token;

                    return axios(axiosConfig)
                });
            }
        }

        return Promise.reject(error);
    }
)