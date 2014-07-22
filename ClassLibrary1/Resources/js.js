// UI functions

var getConversation = function (index, options) {
    options = options ? options : { "from": 0, "howMany": -1 };
    try {
        external.Conversation(index, options.from, options.howMany);
    } catch (e) {
        error(e);
        return;
    };
};

var appendConversation = function (ol, username, date, index) {
    var li = document.createElement("li");
    li.innerHTML = '<span style="float:left">' +username + "</span><span class='date small'>" + date + "<span>";
    li.onclick = function () {
        window.otherUsername = username;
        getConversation(index);
        document.getElementById("textarea").value = '';
        document.getElementById("send").disabled = true;
        this.className += " selected";
    };
    li.className = "clickable convli";
    ol.appendChild(li);
};

var appendMessage = function (ol, message, other, date, received) {
    var li = document.createElement("li");
    var text = "<span class='username'>" + (received ? other : window.username) + "</span><span class='date small'>" + date + " </span></div>" + "<br /> " + message;
    li.className = "message" + (received ? "Left" : "Right");
    li.innerHTML = text;
    ol.appendChild(li);
};

function normalizedDate(stringDate) {
    var date = new Date(parseInt(stringDate.replace(/Date\(([0-9]+)\)/g, "$1").replace(/\//g, ""), 10));
    return date.getDay() + "/" + date.getMonth() + "/" + date.getYear() + " - " + date.getHours() + ":" + date.getMinutes();
};

function showNewConversationForm() {
    var body = document.getElementById("body"), newBody = document.getElementById("newBody");
    if (newBody.innerHTML == '') {
        newBody.innerHTML = '<div><h1 style="float:left; display:inline">New Conversation</h1><span title="Go Back" style="float:right; font-size: 25pt" class="clickable" onclick="showNewConversationForm()">X</span></div><br /><br /><br />'
        + '<div style="width: 80px">To:</div><input type="text" id="otherone" /><br />'
        + '<div style="width: 80px">Message:</div><div style="width:59%;float:left"><textarea id="newtextarea" onkeyup="document.getElementById(\'newsend\').disabled = false"></textarea></div>'
        + '<button disabled id="newsend" class="send" onclick="try { external.Send(document.getElementById(\'otherone\').value, document.getElementById(\'newtextarea\').value); } catch(e) { error(e); return; }; getConversation(0); showNewConversationForm(); location.href = \'#lastMessage\';">Send</button>';

        newBody.style.width = '100%';
        body.style.display = 'none';
        return;
    }
    newBody.innerHTML = '';
    body.style.display = 'block';
}

// Functions called from C#
function setUsername(username) {
    window.username = username;
};

function clearConversations() {
    if (document.getElementById("conversations")) {
        document.getElementById("conversations").innerHTML = "";
    }
};

function clearConversation() {
    if (document.getElementById("conversation")) {
        document.getElementById("conversation").innerHTML = "";
    }
};

function error(error) {
    alert(error.message);
}

function updateConversations(conversations) {
    conversations = eval(conversations);
    for (var c in conversations) {
        var username = conversations[c].OtherName;
        var date = normalizedDate(conversations[c].LastDate);
        appendConversation(document.getElementById("conversations"), username, date, c);
    }
};

function updateMessages(conversation) {
    var messages = eval(conversation);
    for (m in messages) {
        var msg = messages[m];
        appendMessage(document.getElementById("conversation"), msg.Text.replace(/(?:\r\n|\r|\n)/g, '<br />'), msg.Conversation.OtherName, normalizedDate(msg.Date), msg.Received);
    }
    document.getElementById("conversation").innerHTML += '<div id="lastMessage"></div>';
    document.getElementById("form").style.display = 'block';
    location.href = "#lastMessage";
};