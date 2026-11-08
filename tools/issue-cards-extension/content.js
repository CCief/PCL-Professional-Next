/*
 * PCL Professional-Next · Issue 三卡片入口
 * 只在仓库 Issues 列表页注入一排淡彩卡片；样式见 cards.css。
 * GitHub 的 Issues 页是 React/Turbo 驱动，节点会被重建，所以用 MutationObserver 反复挂载。
 */
(() => {
  'use strict';

  const HOST_ID = 'pcln-issue-card-row';
  const ISSUES_PATH = '/CCief/PCL-Professional-Next/issues';

  const CARDS = [
    {
      cls: 'pcln-feature',
      badge: '功能 / 建议',
      emoji: '&#128235;',
      title: '新功能投稿栏',
      desc: '想加什么功能、想改哪处体验？把场景和期望写进来。',
      cta: '提交新功能',
      href: 'https://github.com/CCief/PCL-Professional-Next/issues/new?template=01-feature.yml'
    },
    {
      cls: 'pcln-welcome',
      badge: '先读这里',
      emoji: '&#127881;',
      title: '欢迎来到 PCL Professional-Next！',
      desc: '项目定位、特色功能、血统说明与最新版本下载。',
      cta: '了解这个项目',
      href: 'https://github.com/CCief/PCL-Professional-Next#readme'
    },
    {
      cls: 'pcln-bug',
      badge: '问题 / 崩溃',
      emoji: '&#128027;',
      title: 'Bug 反馈栏',
      desc: '崩了、下载失败、界面错位？带上版本号和复现步骤。',
      cta: '报告一个 Bug',
      href: 'https://github.com/CCief/PCL-Professional-Next/issues/new?template=02-bug.yml'
    }
  ];

  function isIssuesListPage() {
    return location.pathname.replace(/\/+$/, '') === ISSUES_PATH;
  }

  function buildHtml() {
    return CARDS.map(c =>
      '<a class="pcln-card ' + c.cls + '" href="' + c.href + '">' +
        '<span class="pcln-badge">' + c.badge + '</span>' +
        '<span class="pcln-main">' +
          '<span class="pcln-emoji">' + c.emoji + '</span>' +
          '<span class="pcln-title">' + c.title + '</span>' +
        '</span>' +
        '<span class="pcln-desc">' + c.desc + '</span>' +
        '<span class="pcln-cta">' + c.cta + '<span class="pcln-arrow">&#8594;</span></span>' +
      '</a>'
    ).join('');
  }

  function mount() {
    if (!isIssuesListPage() || document.getElementById(HOST_ID)) return;

    const anchor =
      document.querySelector('[data-testid="issues-list-surface"]') ||
      document.querySelector('react-app[app-name="repo"]') ||
      document.querySelector('#repo-content-pjax-container');
    if (!anchor) return;

    const host = document.createElement('div');
    host.id = HOST_ID;
    const wrap = document.createElement('div');
    wrap.className = 'pcln-wrap';
    wrap.innerHTML = buildHtml();
    host.appendChild(wrap);

    if (anchor.getAttribute('data-testid') === 'issues-list-surface' && anchor.parentNode) {
      anchor.parentNode.insertBefore(host, anchor);
    } else {
      anchor.insertBefore(host, anchor.firstChild);
    }
  }

  let queued = false;
  const observer = new MutationObserver(() => {
    if (queued) return;
    queued = true;
    setTimeout(() => {
      queued = false;
      mount();
    }, 80);
  });
  observer.observe(document.documentElement, { childList: true, subtree: true });

  document.addEventListener('turbo:load', () => setTimeout(mount, 80));
  window.addEventListener('popstate', () => setTimeout(mount, 120));

  mount();
})();
