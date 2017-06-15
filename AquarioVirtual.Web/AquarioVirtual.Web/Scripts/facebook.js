   

        window.fbAsyncInit = function () {
            FB.init({
                appId: '169301240256538',
                xfbml: true,
                version: 'v2.8',
                status: true,
                cookie: true
            });
            FB.AppEvents.logPageView();
        };

           //CARREGANDO SDK JS
        (function(d, s, id){
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) {return;}
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));


        //Verifica o status de conexão do usuário
        //FB.Event.subscribe('auth.authResponseChange', function (response) {
        //    if (response.status === 'connected') {
        //        updateUI();
        //    }
        //    //else if (response.status === 'not_authorized') {
        //    //    // Connected to FB but not to the app
        //    //}
        //    else {
        //        FB.login();
        //    }
        //});
        
        $('#btn-fb').click(function (e) {
            FB.Login();
        });

        function loginFace(){
            FB.login(function(response){
                 if (response.status === 'connected') {
                    // alert('Conectado com o facebook');
           }
           else if (response.status === 'not_authorized') {
              alert('Conectado com o facebook, mas não com o aplicativo');
           }
           else {
               alert('Não conectado com o facebook');
                 }

                 getInfo();
            }
            ,{scope: 'public_profile,email'});
            
        };
        
        function getInfo(){
            FB.api('/me','GET',{fields: 'first_name, last_name, name, id'},
            function(response){
                // alert(response.id);
                console.log(response);
                // document.getElementById('exampleInputEmail2').nodeValue = response.name;
               $('.profile-usertitle-name').html(response.name);
               $('.img-thumbnail').attr('src', 'http://graph.facebook.com/' + response.id + '/picture?type=normal');
            });
        }

        // FB.Login(function (response) {


        // }, 
        // {scope: 'public_profile,email'});

        // FB.getLoginStatus(function (response) {
        //     statusChangeCallback(response);
        // });

