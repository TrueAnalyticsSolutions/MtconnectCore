window["fetchMtconnect"] = async (url) => {
    //return new Promise((resolve, reject) => {
    //    let xhr = new XMLHttpRequest()
    //    xhr.open('GET', url)
    //    xhr.withCredentials = true;
    //    xhr.setRequestHeader('Content-Type', 'text/xml');
    //    xhr.onload = e => {
    //        if (xhr.readyState === 4) {
    //            if (xhr.status === 200) {
    //                //console.log(xhr.responseText)
    //                resolve(xhr.responseXML)
    //            }
    //            else {
    //                //console.error(xhr.statusText)
    //                reject(xhr.statusText)
    //            }
    //        }
    //    }

    //    xhr.onerror = e => {
    //        //console.error(xhr.statusText)
    //        reject(xhr.statusText)
    //    }

    //    xhr.send(null)
    //})
    return await fetch(
            url,
            {
                mode: 'no-cors',
                contentType: 'text/xml'
            }
        )
        .then(response => response.text())
        .then(str => {
            if (str !== null && str !== "") {
                return new window.DOMParser().parseFromString(str, "text/xml");
            }
            return null;
        })
        .then(data => {
            return data;
        })
        .catch(err => {
            console.error("Failed to fetch MTConnect response: ", err);
            return null;
        });
};
