

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Apache2 License][license-shield]][license-url]




<!-- no css, so have to use align -->
<div align="center">
	<h1>Mosquito (and bee) sound suppressor</h1>
	<p>
		A <a href="http://www.derailvalley.com/">Derail Valley</a> mod which loads via <a href="https://www.nexusmods.com/site/mods/21">Unity Mod Manager</a>.
		<br />
		<a href="https://github.com/brunoais-derailValley/NoMosquito/issues">Report Bug</a>
		·
		<a href="https://github.com/brunoais-derailValley/NoMosquito/issues">Request Feature</a>
	</p>
</div>

# Installation

## Prerequisites

### Install Unity Mod Manager

A member already made a guide for this at: https://steamcommunity.com/sharedfiles/filedetails/?id=3008093053#6402758

## Download mod

Download mod either from

### Releases here on github

Download zip file from [Releases](https://github.com/brunoais-derailValley/NoMosquito/releases/latest)

### From nexus mods

(TBA)

## Actual installation

A member already made a guide for this at: https://steamcommunity.com/sharedfiles/filedetails/?id=3008093053#6402835


# Contributing

Besides the usual for most mods, this codebase assumes in `.csproj` that you have a symlink ([windows](https://learn.microsoft.com/en-us/windows/security/threat-protection/security-policy-settings/create-symbolic-links)/[unix](https://en.wikipedia.org/wiki/Symbolic_link)) to your `Derail Valley` installation directory in the same directory as `LICENSE` file. If you don't, then either you make one or you need to modify it accordingly and you ***must* not commit it**.


## How mod works

It patches itself to `UnityEngine.AudioSource.PlayOneShot` which is what Derail Valley uses to play the environment sounds.  

Then, if the name of the sound clip matches the hardcoded string, the call to `PlayOneShot` is blocked and the execution continues normally.


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/brunoais-derailValley/NoMosquito.svg?style=for-the-badge
[contributors-url]: https://github.com/brunoais-derailValley/NoMosquito/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/brunoais-derailValley/NoMosquito.svg?style=for-the-badge
[forks-url]: https://github.com/brunoais-derailValley/NoMosquito/network/members
[stars-shield]: https://img.shields.io/github/stars/brunoais-derailValley/NoMosquito.svg?style=for-the-badge
[stars-url]: https://github.com/brunoais-derailValley/NoMosquito/stargazers
[issues-shield]: https://img.shields.io/github/issues/brunoais-derailValley/NoMosquito.svg?style=for-the-badge
[issues-url]: https://github.com/brunoais-derailValley/NoMosquito/issues
[license-shield]: https://img.shields.io/github/license/brunoais-derailValley/NoMosquito.svg?style=for-the-badge
[license-url]: https://github.com/brunoais-derailValley/NoMosquito/blob/master/LICENSE
[references-url]: https://learn.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2022
[autocrlf-url]: https://www.git-scm.com/book/en/v2/Customizing-Git-Git-Configuration#_formatting_and_whitespace
