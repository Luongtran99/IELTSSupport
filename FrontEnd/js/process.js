const SPACE = 32;
const ENTER = 13;
const QUESTION = 191;
const Phay = 190;
const DIGIT1 = 49;
const DIGIT2 = 50;
const SEMICOLON = 186;
const QUOTE = 222;
const PERIOD = 188;
const BRACKETLEFT = 219;
const BRACKETRIGHT = 221;
const DIGIT9 = 57;
const DIGIT10 = 48;

// get save click

/*
 * Sai đến đâu sửa đến đó
 *
 */

// get event input to check word
document
  .querySelector("#editor_area")
  .addEventListener("keyup", async function (event) {
    //console.log(this.selectionStart);
    //console.log("Xet");
    // get text
    if (
      event.keyCode == SPACE ||
      event.keyCode == ENTER ||
      event.keyCode == QUESTION ||
      event.keyCode == DIGIT1 ||
      event.keyCode == SEMICOLON
    ) {

      var regex = /([a-z]|[A-Z])\w+/g;
      // split text
      var splitChar = this.innerText.match(regex);

      if (splitChar != null) {
        // spell check
        //splitChar[splitChar.length - 1]
        spellCheck(splitChar[splitChar.length - 1]);
      }
    }
  });

// check basic grammar
async function spellCheck(word) {
  // create request Options
  var requestOptions = {
    method: "GET",
    redirect: "follow",
  };
  // URL + parameter
  await fetch(
    "https://localhost:44391/api/spell/search/" + word.trim(),
    requestOptions
  )
    .then((response) => response.json())
    .then((result) => {
      var getsupport = document.getElementById("spwordlist");
      getsupport.innerHTML = "";

      if (result.code === 200) {
        var newli = document.createElement("li");
        newli.innerText = word;
        getsupport.appendChild(newli);
      } else {
        for (let i = 0; i < result.obj.length; i++) {
          var newli = document.createElement("li");
          newli.innerText = result.obj[i].word;
          getsupport.appendChild(newli);
        }
      }
    })
    .catch((error) => console.log(error));
}

// get selection text when right click
// then send it wrong word to server
document
  .querySelector("#editor_area")
  .addEventListener("contextmenu", async function (e) {
    e.preventDefault();

    // send wrong word to server
    var requestOptions = {
      method: "GET",
      redirect: "follow",
    };

    if(window.getSelection().toString() != ""){
      await fetch(
      "https://localhost:44391/api/spell/search/" + document.getSelection().toString().trim() ||
        window.getSelection().toString().trim(),
      requestOptions)
      .then((response) => response.json())
      .then((result) => {
        var getsupport = document.getElementById("spwordlist");
        getsupport.innerHTML = "";

      if (result.code === 200) {
        var newli = document.createElement("li");
        newli.innerText = word;
        getsupport.appendChild(newli);
      } else {
        for (let i = 0; i < result.obj.length; i++) {
          var newli = document.createElement("li");
          newli.innerText = result.obj[i].word;
          getsupport.appendChild(newli);
        }
      }
      })
      .catch((error) => console.log(error));
    }
    else{
      // do nothing
    }
  });

// show support word
document
  .querySelector("#spwordlist")
  .addEventListener("contextmenu", async function (e) {
    e.preventDefault();

    // send wrong word to server
    var requestOptions = {
      method: "GET",
      redirect: "follow",
    };

    if(window.getSelection().toString() != ""){

      var xword = document.getSelection().toString().trim() ||
      window.getSelection().toString().trim();

      await fetch(
      "https://localhost:44391/api/dictionary/" + xword,
      requestOptions)
      .then((response) => response.json())
      .then((result) => {
        //console.log(result);
        var x = document.querySelector("#meaning");
       // pre process
       x.querySelector("#word").innerHTML = "";
       //x.querySelector("#partOfSpeech").innerHTML = "";
       document.getElementById("audiolist").innerHTML = "";
       document.getElementById("wordmeaning").innerHTML = "";

       // end 


        x.querySelector("#word").innerHTML = xword;
        //x.querySelector("#partOfSpeech").innerHTML = result.obj.meanings[0].partOfSpeech;
        
        // add audio
        for(let i = 0; i < result.obj.phonetics.length; i++){
          var newau = new Audio('data:audio/ogg;base64,'+result.obj.phonetics[i].audio);
          newau.style.cssText = "width:100px;"
          newau.controls = true;
          document.getElementById("audiolist").appendChild(newau);

          var a = document.createElement("h4");
          a.innerHTML = result.obj.phonetics[i].text;
          document.getElementById("audiolist").appendChild(a);
        }

        for(let i = 0; i < result.obj.meanings.length; i++){
          var newdiv = document.createElement("div");
          var h2 = document.createElement("h4");
          h2.innerHTML = result.obj.meanings[i].partOfSpeech;
          newdiv.appendChild(h2);
          for(let j = 0; j < result.obj.meanings[i].definitions.length; j++){
            var newdiv2 = document.createElement("div");
            newdiv2.innerHTML = "<span style=\"font-size:2rem\">definition</span>:" + result.obj.meanings[i].definitions[j].definition +
            "<br>"+
            "<span style=\"font-size:2rem\">example</span>:"+result.obj.meanings[i].definitions[j].example+
            "<br>"+
            "<span style=\"font-size:2rem\">synonyms</span>:"+result.obj.meanings[i].definitions[j].synonyms+
            "<hr>"
            ;
            newdiv.appendChild(newdiv2);
          }
          document.getElementById("wordmeaning").appendChild(newdiv);
        }

      })
      .catch((error) => console.log(error));
    }
    else{
      // do nothing
    }
  });

function load() {
        if(localStorage.getItem("token") != null){
        var getRightHeading = document.querySelector(".right");
        getRightHeading.innerHTML = "<div class=\"navelement\">"+
          "<a href=\"/index.html\" onclick=\"localStorage.clear()\" style=\"color: black;font-size:1.5rem; margin:10px\">Logout</a></div>";
      }
}


document
  .querySelector("#save")
  .addEventListener("click", function(){

    if(localStorage.getItem("accessToken") == null){
      alert("you must login to use this feature");
    }
    else{
      var myHeader = new Headers();
      myHeader.append("Content-Type", "application/json");
      myHeader.append("Authorization", "Bearer "+localStorage.getItem("accessToken"));

      var getContent = document.getElementById("editor_area").innerHTML;
      var getTopic = document.getElementById("topic").innerHTML;

      if(getContent == null || getTopic == null){
        alert("Không được phép null");
      }
      else
      {
        var _body = JSON.stringify({
          "text":getContent,
          "topic":getTopic
        });

        var requestOptions = {
          method:"POST",
          headers:myHeader,
          body:_body,
          redirect:"follow"
        };

        fetch("https://localhost:44391/api/essay", requestOptions)
        .then(response => response.json())
        .then(result => 
          {
            if(result == null){
              alert("opps! có lỗi xảy ra");
            }
            else{
              alert("Đăng bài thành công");
            }
          })
        .catch(error => console.log(error));
      }
    }
  }
)