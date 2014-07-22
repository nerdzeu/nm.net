// UI functions

var getConversation = function (index, options) {
    options = options ? options : { "from": 0, "howMany": 10 };
    external.Conversation(index, options.from, options.howMany);
};

var appendConversation = function (ol, username, date, index) {
    var li = document.createElement("li");
    var text = document.createTextNode(username);
    li.onclick = function () {
        window.otherUsername = username;
        getConversation(index);
    };
    li.appendChild(text);
    ol.appendChild(li);
};

var appendMessage = function (ol, message, other, date, received) {
    var li = document.createElement("li");
    var text = (received ? other : window.username) + " [ " + date + " ]" + "<br /> " + message;
    li.className = "message" + (received ? "Left" : "Right");
    li.innerHTML = text;
    ol.appendChild(li);
};

function normalizedDate(stringDate) {
    return new Date(parseInt(stringDate.replace(/Date\(([0-9]+)\)/g, "$1").replace(/\//g, ""), 10));
};

// Functions called from C#
function setUsername(username) {
    window.username = username;
};

function clearConversations() {
    document.getElementById("conversations").innerHTML = "";
};

function clearConversation() {
    document.getElementById("conversation").innerHTML = "";
};

function error(error) {
    var div = document.createElement("div"),
        btn = document.createElement("button");

    btn.onclick = function () {
        document.removeChild(document.getElementById("errorDiv"));
    }
    div.innerHTML = "[!] " + error;
    div.id = "errorDiv";
    div.style.zIndex = 2000;
    div.style.width = window.innerWidth;
    div.style.height = window.innerHeight;

    document.appendChild(div);
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
        appendMessage(document.getElementById("conversation"), msg.Text, msg.Conversation.OtherName, normalizedDate(msg.Date), msg.Received);
    }
    document.getElementById("form").style.display = 'block';
};