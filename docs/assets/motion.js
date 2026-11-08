/* PCL Professional-Next 官网 · 动效层
   纯原生 JS，零依赖。尊重系统的「减少动效」偏好：
   页面 <head> 已在该偏好开启时不添加 .js-motion，本文件随之跳过全部动效。 */
(function () {
  'use strict';

  var root = document.documentElement;
  var reduced = !root.classList.contains('js-motion') ||
                !!(window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches);

  /* ---- Issue 列表：逐条入场编号、离线状态标记（与动效开关无关） ---- */
  var list = document.getElementById('issue-list');
  if (list && window.MutationObserver) {
    var applyRows = function () {
      Array.prototype.forEach.call(list.querySelectorAll('.issue-item'), function (li, i) {
        li.style.setProperty('--i', i);
      });
    };
    new MutationObserver(applyRows).observe(list, { childList: true });
    applyRows();
  }

  var live = document.getElementById('board-live');
  if (live && window.MutationObserver) {
    var syncLive = function () {
      live.classList.toggle('is-offline', live.textContent.indexOf('离线') >= 0);
    };
    new MutationObserver(syncLive).observe(live, { childList: true, characterData: true, subtree: true });
    syncLive();
  }

  if (reduced) return;

  /* ---- Hero：浮动光斑 + 鼠标跟随光晕 ---- */
  var hero = document.querySelector('.hero');
  if (hero) {
    ['orb--1', 'orb--2', 'orb--3'].forEach(function (cls) {
      var orb = document.createElement('div');
      orb.className = 'orb ' + cls;
      hero.appendChild(orb);
    });

    var glow = document.createElement('div');
    glow.className = 'cursor-glow';
    hero.appendChild(glow);

    hero.addEventListener('pointermove', function (e) {
      var r = hero.getBoundingClientRect();
      glow.style.setProperty('--gx', (e.clientX - r.left) + 'px');
      glow.style.setProperty('--gy', (e.clientY - r.top) + 'px');
      glow.style.opacity = '1';
    }, { passive: true });
    hero.addEventListener('pointerleave', function () { glow.style.opacity = '0'; });
  }

  /* ---- 滚动入场：内容默认可见，动画只是增强 ----
     即使 IntersectionObserver 不触发，元素也照常显示，绝不会白屏。 */
  var groups = [
    ['.section-head', 0],
    ['.cards .card', 110],
    ['.features .feature', 70],
    ['.channels .channel', 110],
    ['.issue-board', 0],
    ['.download-card', 0],
    ['.warn', 0],
    ['.footer-grid > div', 90]
  ];
  var targets = [];
  groups.forEach(function (g) {
    Array.prototype.forEach.call(document.querySelectorAll(g[0]), function (el, i) {
      if (g[1]) el.style.setProperty('--d', Math.min(i, 6) * g[1] + 'ms');
      targets.push(el);
    });
  });

  var io = ('IntersectionObserver' in window)
    ? new IntersectionObserver(function (entries) {
        entries.forEach(function (en) {
          if (en.isIntersecting) {
            en.target.classList.add('scroll-in');
            io.unobserve(en.target);
          }
        });
      }, { threshold: 0.1, rootMargin: '0px 0px -30px 0px' })
    : null;

  // 视口内的立即播放；视口外的交给 IO，触发不了就保持静态可见
  targets.forEach(function (el) {
    var r = el.getBoundingClientRect();
    if (!io || r.top < window.innerHeight + 60) el.classList.add('scroll-in');
    else io.observe(el);
  });

  /* ---- 三张卡片的 3D 倾斜 ---- */
  Array.prototype.forEach.call(document.querySelectorAll('.cards .card'), function (card) {
    card.addEventListener('pointermove', function (e) {
      var r = card.getBoundingClientRect();
      var px = (e.clientX - r.left) / r.width - 0.5;
      var py = (e.clientY - r.top) / r.height - 0.5;
      card.style.setProperty('--rx', (-py * 8).toFixed(2) + 'deg');
      card.style.setProperty('--ry', (px * 8).toFixed(2) + 'deg');
    }, { passive: true });
    card.addEventListener('pointerleave', function () {
      card.style.setProperty('--rx', '0deg');
      card.style.setProperty('--ry', '0deg');
    });
  });

  /* ---- 顶栏滚动阴影 ---- */
  var bar = document.querySelector('.topbar');
  if (bar) {
    var onScroll = function () {
      if (window.scrollY > 12) bar.classList.add('scrolled');
      else bar.classList.remove('scrolled');
    };
    window.addEventListener('scroll', onScroll, { passive: true });
    onScroll();
  }
})();
