function parseJwt(){
    var token = localStorage.getItem('user-token');
    
    // O TypeScript necessita que haja uma verificação caso token seja nulo
    if(token == null) return null

    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/'); 
    return JSON.parse(window.atob(base64));
}

export default parseJwt;