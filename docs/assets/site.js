/* PCL Professional-Next 官网 · 读取公开 GitHub Issues 并自己渲染列表
   纯原生 JS，无依赖；网络不可用时回退到离线快照。 */
(function () {
  'use strict';

  var REPO = 'CCief/PCL-Professional-Next';
  var API = 'https://api.github.com/repos/' + REPO +
            '/issues?state=all&per_page=20&sort=updated&direction=desc';

  var FALLBACK = [
    { number: 2, state: 'open', title: '🟦 📫 新功能投稿栏',
      html_url: 'https://github.com/' + REPO + '/issues/2',
      labels: [{ name: '📫 投稿栏', color: 'dbeafe' }], updated_at: '2026-11-08T00:00:00Z' },
    { number: 3, state: 'open', title: '🌈 🎉 欢迎来到 PCL Professional-Next！',
      html_url: 'https://github.com/' + REPO + '/issues/3',
      labels: [{ name: '🎉 欢迎', color: 'fce7f3' }, { name: '🌈 淡彩', color: 'fef3c7' }],
      updated_at: '2026-11-08T00:00:00Z' },
    { number: 4, state: 'open', title: '🟩 🐛 Bug 反馈栏',
      html_url: 'https://github.com/' + REPO + '/issues/4',
      labels: [{ name: '🐛 反馈栏', color: 'd1fae5' }], updated_at: '2026-11-08T00:00:00Z' }
  ];

  var listEl = document.getElementById('issue-list');
  var liveEl = document.getElementById('board-live');
  var noteEl = document.getElementById('board-note');
  if (!listEl) return;

  function readableText(hex) {
    var c = String(hex || 'dddddd').replace('#', '');
    if (c.length === 3) c = c[0] + c[0] + c[1] + c[1] + c[2] + c[2];
    var n = parseInt(c.slice(0, 6), 16);
    if (isNaN(n)) return '#3a4757';
    var r = (n >> 16) & 255, g = (n >> 8) & 255, b = n & 255;
    return (r * 299 + g * 587 + b * 114) / 1000 > 150 ? '#3a4757' : '#ffffff';
  }

  function shortDate(iso) {
    var d = new Date(iso);
    if (isNaN(d.getTime())) return '';
    return d.toLocaleDateString('zh-CN', { month: '2-digit', day: '2-digit' });
  }

  function render(items, offline) {
    listEl.replaceChildren();
    items.slice(0, 6).forEach(function (it) {
      var li = document.createElement('li');
      li.className = 'issue-item';

      var state = document.createElement('span');
      var isOpen = it.state === 'open';
      state.className = 'issue-state ' + (isOpen ? 'state-open' : 'state-closed');
      state.textContent = isOpen ? '●' : '✓';
      state.title = isOpen ? '进行中' : '已关闭';
      li.appendChild(state);

      var link = document.createElement('a');
      link.className = 'issue-title';
      link.href = it.html_url;
      link.target = '_blank';
      link.rel = 'noopener';
      var num = document.createElement('span');
      num.className = 'issue-num';
      num.textContent = '#' + it.number;
      link.appendChild(num);
      link.appendChild(document.createTextNode(it.title));
      li.appendChild(link);

      var labels = document.createElement('span');
      labels.className = 'issue-labels';
      (it.labels || []).slice(0, 2).forEach(function (lb) {
        var tag = document.createElement('span');
        tag.className = 'lbl';
        tag.style.background = '#' + lb.color;
        tag.style.color = readableText(lb.color);
        tag.textContent = lb.name;
        labels.appendChild(tag);
      });
      li.appendChild(labels);

      var time = document.createElement('time');
      time.className = 'issue-time';
      time.textContent = shortDate(it.updated_at);
      li.appendChild(time);

      listEl.appendChild(li);
    });

    liveEl.textContent = offline ? '离线快照 · GitHub API 不可用' : '实时同步 · 来自 GitHub';
    noteEl.textContent = offline
      ? '当前显示的是三个导航 Issue 的离线快照。网络恢复后刷新页面即可看到真实列表，内容以 GitHub 为准。'
      : '列表来自公开的 GitHub REST API，按最近更新排序；点击任意一条可跳到 GitHub 参与讨论。';
  }

  var controller = typeof AbortController !== 'undefined' ? new AbortController() : null;
  var timer = controller ? setTimeout(function () { controller.abort(); }, 7000) : null;

  fetch(API, {
    headers: { Accept: 'application/vnd.github+json' },
    signal: controller ? controller.signal : undefined
  })
    .then(function (res) {
      if (!res.ok) throw new Error('HTTP ' + res.status);
      return res.json();
    })
    .then(function (data) {
      if (timer) clearTimeout(timer);
      var issues = (Array.isArray(data) ? data : [])
        .filter(function (x) { return !x.pull_request; });
      if (!issues.length) throw new Error('empty');
      render(issues, false);
    })
    .catch(function () {
      if (timer) clearTimeout(timer);
      render(FALLBACK, true);
    });
})();
