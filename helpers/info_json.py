#!/bin/python3

import json
import sys
from functools import partial

from pathlib import Path

from helpers.derail_valley_symlink import dv_mods_dir

printe = partial(print, file=sys.stderr)

project_dir = Path(__file__).parent.parent.absolute()
printe(project_dir)


with open(project_dir / "info.json") as f:
	info = json.load(f)
mod_id = info['Id']
mod_version = info['Version']
dv_mod_dir = dv_mods_dir / mod_id
installed_info_json = dv_mod_dir / "info.json"
